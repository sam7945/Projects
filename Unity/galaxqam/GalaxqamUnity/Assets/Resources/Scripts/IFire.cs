public interface IFire
{
    int Munition { get; }
    int DefaultMunitionAmount { get; }
    bool isPlaying { get; }
    public void fire();
    public void resetMunitionAmount();
    public void addMunition(int munition);
    public bool isEmpty { get; }
    int MUNITIONS_A_AJOUTER { get; }
}
