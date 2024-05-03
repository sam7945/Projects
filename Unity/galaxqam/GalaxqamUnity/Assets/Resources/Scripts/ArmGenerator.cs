using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// À l'équipe du boss:
// Ceci est un script d'exemple et du résultat attendu avec le hinge joint
// Vous pouvez vous inspirer de ce script et même en prendre des partie ou le
// changer pour vos besoin.
//
// Je vous invite à regarder la structure dans la scène ArmGeneratorTest.


public class ArmGenerator : MonoBehaviour
{
    public GameObject armSegment; //Je garde en mémoire le prefab
    public int nbSegments; // Le nombre de segments attendu...
    public GameObject[] anchors; // les points de fixations (épaules)
    public float marginConnectorA; // le gap entre les joints
    public float marginConnectorB; // pas sur encore si nécessaire

    // Start is called before the first frame update
    void Start()
    {
        Init(); // On initialise
        GenerateArms(); // On génère

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init(){
        // Initialisation à titre d'exemple
        nbSegments = 7;
        armSegment =
            Resources.Load("Prefabs/boss_arm_segment_aligned") as GameObject;
        anchors = new GameObject[1]; // les épaules, pour l'instant une seule.
        anchors[0] = GameObject.Find("Shoulder"); // Va chercher l'épaule.
        marginConnectorA=0.7f; // actualise la distance entre les noeuds
    }

    void GenerateArms(){
        HingeJoint actualHingeJoint; // Garder en mémoire les joints pour la construction
        GameObject armPart = null; // pour la compilation (si pas initialisé)

        for(int j = 0; j < anchors.Length; ++j){ // pour chaque épaules
            Vector3 iPosition = anchors[j].transform.position; // Va chercher la position de l'épaule
            Quaternion iRotation = anchors[j].transform.rotation;
            if(!anchors[j].GetComponent<Rigidbody>()){ // s'assure qu'il y a un rigidbody dans l'épaule
                anchors[j].AddComponent<Rigidbody>(); // Sinon, on en créé un
            }
            anchors[j].AddComponent<HingeJoint>(); // on ajoute un HingeJoint à l'épaule
            actualHingeJoint = anchors[j].GetComponent<HingeJoint>(); // On l'assigne à la variable
            actualHingeJoint.axis = Vector3.forward; // Set l'axe de rotation du joint



            for(int i = 0; i < nbSegments; ++i){

                // Génère et instantie le segment de bras
                armPart = Instantiate(armSegment, iPosition, iRotation, anchors[j].transform);
                // On avance la postion pour la prochaine génération de bras
                iPosition.x += marginConnectorA;
                // On fixe le connecteur au rigidbody du nouveau segment
                actualHingeJoint.connectedBody = armPart.GetComponent<Rigidbody>();
                // On s'assure qu'on utilise la gravité
                armPart.GetComponent<Rigidbody>().useGravity=true;
                // On va chercher le hingeJoint du nouveau segment créé
                actualHingeJoint = armPart.GetComponent<HingeJoint>();
            }

            // Pour démonstration, pour avoir un mouvement dans le bras
            // Puisque si vous avez un hingeJoint non attaché il restera dans
            // les airs...
            Destroy(armPart.GetComponent<HingeJoint>());

            // On ajoute ensuite un script pour appliquer de la
            // force au dernier maillon.
            armPart.AddComponent<EnemyForceMovement>();

        }

    }
}
