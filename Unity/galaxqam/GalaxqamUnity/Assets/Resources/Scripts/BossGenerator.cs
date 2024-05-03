using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// À l'équipe du boss:
// Ceci est un script d'exemple et du résultat attendu avec le hinge joint
// Vous pouvez vous inspirer de ce script et même en prendre des partie ou le
// changer pour vos besoin.
//
// Je vous invite à regarder la structure dans la scène ArmGeneratorTest.


public class BossGenerator : MonoBehaviour
{
    public GameObject armSegment; //Je garde en mémoire le prefab
    public int nbSegments; // Le nombre de segments attendu...
    public GameObject[] anchors; // les points de fixations (épaules)
    public GameObject vaisseau;
    public GameObject[] vaisseaux;
    public float marginConnectorA; // le gap entre les joints
    public float marginConnectorB; // pas sur encore si nécessaire
    public int nbBras;
    public float modifierRotation;

    // Start is called before the first frame update
    void Start()
    {
        InitScene(); // On initialise
        GenerateBossArms(); // On génère

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitScene(){
        // Initialisation à titre d'exemple
        nbBras = 6;
        nbSegments = 7;
        armSegment =
            Resources.Load("Prefabs/boss_arm_segment") as GameObject;
        vaisseau = GameObject.Find("boss_prototype03");
        anchors = new GameObject[nbBras]; // les épaules
        vaisseaux = new GameObject[nbBras];
        for(int i = 0; i<nbBras ; i++){
            string nomAttache = "attache" + (i+1);
            string nomBras = "bras" + (i+1);
            GameObject bras = GameObject.Find(nomBras);
            anchors[i] = GameObject.Find(nomAttache); // Va chercher l'épaule.
            string nomVaisseau = "Prefabs/Enemy" + (i+1);
            vaisseaux[i] = Resources.Load(nomVaisseau) as GameObject;
            anchors[i].transform.parent = vaisseau.transform;
            bras.transform.parent = vaisseau.transform;
        }

        //Rendre le vaisseau parent des parties
        GameObject cannon = GameObject.Find("Canon");
        cannon.transform.parent = vaisseau.transform;
        for(int i = 0; i<3 ; i++){
            string nomMoteur = "Moteur" + (i+1);
            GameObject moteur = GameObject.Find(nomMoteur);
            moteur.transform.parent = vaisseau.transform;
        }
        marginConnectorA=10.0f; // actualise la distance entre les noeuds
    }

    void GenerateBossArms(){
        HingeJoint actualHingeJoint; // Garder en mémoire les joints pour la construction
        GameObject armPart = null; // pour la compilation (si pas initialisé)
        HingeJoint hingeVaisseau;

        if(!vaisseau.GetComponent<Rigidbody>()){ // s'assure qu'il y a un rigidbody dans le vaisseau
                vaisseau.AddComponent<Rigidbody>(); // Sinon, on en créé un
                vaisseau.GetComponent<Rigidbody>().useGravity=false;
            }
        vaisseau.AddComponent<HingeJoint>();
        hingeVaisseau = vaisseau.GetComponent<HingeJoint>();


        for(int j = 0; j < anchors.Length; ++j){ // pour chaque épaules
            GameObject oldArm = vaisseau;
            if(j==anchors.Length/2){
                marginConnectorA*=-1.0f; //Pour les bras de gauche
            }
            Vector3 iPosition = anchors[j].transform.position; // Va chercher la position de l'épaule
            Quaternion iRotation = anchors[j].transform.rotation;


            if(j<anchors.Length/2){
                iRotation.z = 180 ;
            }else{
                iRotation.x = 180f;
            }

            if(!anchors[j].GetComponent<Rigidbody>()){ // s'assure qu'il y a un rigidbody dans l'épaule
                anchors[j].AddComponent<Rigidbody>(); // Sinon, on en créé un
            }




            anchors[j].AddComponent<HingeJoint>(); // on ajoute un HingeJoint à l'épaule
            actualHingeJoint = anchors[j].GetComponent<HingeJoint>(); // On l'assigne à la variable
            actualHingeJoint.axis = Vector3.forward; // Set l'axe de rotation du joint
            //hingeVaisseau.connectedBody = anchors[j].GetComponent<Rigidbody>(); //On joint l'epaule au vaisseau
            anchors[j].GetComponent<HingeJoint>().connectedBody = oldArm.GetComponent<Rigidbody>();
            oldArm = anchors[j];



            for(int i = 0; i < nbSegments; ++i){

                // Génère et instantie le segment de bras
                armPart = Instantiate(armSegment, iPosition, iRotation, anchors[j].transform);
                // On avance la postion pour la prochaine génération de bras
                iPosition.x += marginConnectorA;
                // On va chercher le hingeJoint du nouveau segment créé
                actualHingeJoint = armPart.GetComponent<HingeJoint>();
                // On fixe le connecteur au rigidbody du vieux segment
                actualHingeJoint.connectedBody = oldArm.GetComponent<Rigidbody>();
                // On change le vieux pour le nouveau segment
                oldArm = armPart;

            }

            //set la rotation avant de generer le vaisseau
            iRotation.x = 0;
            iRotation.y = 0;
            iRotation.z = 0;
            // Genere le vaisseau
            armPart = Instantiate(vaisseaux[j], iPosition, iRotation, anchors[j].transform);
            // On change le hinge vers le vaisseau
            armPart.AddComponent<HingeJoint>();
            actualHingeJoint = armPart.GetComponent<HingeJoint>();

            //On fixe le vaisseau au dernier segment
            actualHingeJoint.connectedBody = oldArm.GetComponent<Rigidbody>();

            // Pour démonstration, pour avoir un mouvement dans le bras
            // Puisque si vous avez un hingeJoint non attaché il restera dans
            // les airs...
            //Destroy(armPart.GetComponent<HingeJoint>());

        }

    }
}
