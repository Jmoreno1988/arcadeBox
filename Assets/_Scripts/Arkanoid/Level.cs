
public class Level {

    public string nameLevel;
    public int totalBricks;
    public string[] powerUps;

	public Level(string nLevel, int tBricks, string[] powUps)
    {
        nameLevel = nLevel;
        totalBricks = tBricks;
        powerUps = powUps;
    }
}