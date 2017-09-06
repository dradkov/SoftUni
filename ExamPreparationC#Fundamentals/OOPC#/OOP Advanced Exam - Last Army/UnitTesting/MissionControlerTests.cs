using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private Army army;
    private WareHouse warehouse;
    private MissionController mc;
    private AmmunitionFactory ammoFactory;

    [SetUp]
    public void InitializeTests()
    {
        this.army = new Army();
        this.warehouse = new WareHouse();
        this.ammoFactory = new AmmunitionFactory();

        var soldier = new Corporal("Ivan", 30, 25.5, 100.0);
        var missingWeapons = soldier.Weapons.Keys.ToList();
        foreach (var weaponKey in missingWeapons)
        {
            soldier.Weapons[weaponKey] = this.ammoFactory.CreateAmmunition(weaponKey);
        }

        this.army.AddSoldier(soldier);
        this.mc = new MissionController(this.army, this.warehouse);
    }

    [Test]
    public void FailMissionsOnHoldDeletesMissions()
    {
        var easy = new Easy(200.0);
        this.mc.Missions.Enqueue(easy);

        this.mc.FailMissionsOnHold();
        Assert.AreEqual(0, this.mc.Missions.Count);
    }

    [Test]
    public void FailedMissionIncreasesFailedCounter()
    {
        var easy = new Easy(10.0);
        var medium = new Medium(150.0);
        var hard = new Hard(200.0);
        this.mc.Missions.Enqueue(easy);
        this.mc.Missions.Enqueue(medium);
        this.mc.Missions.Enqueue(hard);

        this.mc.PerformMission(hard);
        Assert.AreEqual(1, this.mc.FailedMissionCounter);
    }

    [Test]
    public void MissionOnHold()
    {
        var mission = new Hard(200.0);
        var resultString = this.mc.PerformMission(mission).Trim();
        var expectedString = string.Format(OutputMessages.MissionOnHold, mission.Name);
        Assert.AreEqual(expectedString, resultString);
    }

    [Test]
    public void MoreThanThreeMissionsInQueueShouldDeclineMission()
    {
        var easy = new Easy(200.0);
        var medium = new Medium(200.0);
        var hard = new Hard(200.0);
        this.mc.Missions.Enqueue(easy);
        this.mc.Missions.Enqueue(medium);
        this.mc.Missions.Enqueue(hard);

        var resultString = this.mc.PerformMission(hard).Trim();
        var expectedString = "Mission declined - Suppression of civil rebellion\r\nMission on hold - Capturing dangerous criminals\r\nMission on hold - Disposal of terrorists\r\nMission on hold - Disposal of terrorists";
        Assert.AreEqual(expectedString, resultString);
    }

    [Test]
    public void MissionSuccessful()
    {
        var mission = new Easy(10.0);
        var result = this.mc.PerformMission(mission).Trim();
        var expectedString = string.Format("Mission completed - {0}", mission.Name);
        Assert.AreEqual(expectedString, result);
    }
}