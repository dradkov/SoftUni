using System;
using System.Linq;
using System.Text;

public class GameController : IGameControler
{
    private Army army;
    private WareHouse wareHouse;
    private MissionFactory missionfactory;
    private SoldierFactory soldierFactory;
    private MissionController missionController;
    private StringBuilder output;

    public GameController()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionfactory = new MissionFactory();
        this.soldierFactory = new SoldierFactory();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.output = new StringBuilder();
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();
        var type = data[1];

        if (data[0].Equals("Soldier"))
        {
            if (data.Length == 3)
            {
                type = data[2];
                this.army.RegenerateTeam(type);
            }
            else
            {
                string name = data[2];
                int age = int.Parse(data[3]);
                double experience = double.Parse(data[4]);
                double endurance = double.Parse(data[5]);
                ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

                if (this.wareHouse.SoldierCanBeEquipped(soldier))
                {
                    this.wareHouse.EquipSoldier(soldier);
                    this.AddSoldierToArmy(soldier);
                }
                else
                {
                    this.output.AppendLine(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
                    throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
                }
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wareHouse.AddAmmunitions(this.wareHouse.CreateAmmunition(name), number);
        }
        else if (data[0].Equals("Mission"))
        {
            double score = double.Parse(data[2]);
            string missionResult = this.missionController.PerformMission(this.missionfactory.CreateMission(type, score));
            this.output.AppendLine(missionResult.Trim());
        }
    }

    public string RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        this.output.AppendLine("Results:");
        this.output.AppendLine($"Successful missions - {this.missionController.SuccessMissionCounter}");
        this.output.AppendLine($"Failed missions - {this.missionController.FailedMissionCounter}");
        this.output.AppendLine("Soldiers:");
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.output.AppendLine($"{soldier.Name} - {soldier.OverallSkill}");
        }

        return this.output.ToString().Trim();
    }

    private void AddSoldierToArmy(ISoldier soldier)
    {
        this.army.AddSoldier(soldier);
    }
}