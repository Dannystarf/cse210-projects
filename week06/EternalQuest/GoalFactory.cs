using System;

namespace EternalQuest
{
    public static class GoalFactory
    {
        public static Goal CreateGoal(string stringRepresentation)
        {
            string[] parts = stringRepresentation.Split(':');
            if (parts.Length < 2) return null;

            string goalType = parts[0];
            string[] details = parts[1].Split(',');

            try
            {
                switch (goalType)
                {
                    case "SimpleGoal":
                        if (details.Length >= 4)
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                            simpleGoal.SetComplete(bool.Parse(details[3]));
                            return simpleGoal;
                        }
                        break;

                    case "EternalGoal":
                        if (details.Length >= 3)
                        {
                            return new EternalGoal(details[0], details[1], int.Parse(details[2]));
                        }
                        break;

                    case "ChecklistGoal":
                        if (details.Length >= 6)
                        {
                            ChecklistGoal checklistGoal = new ChecklistGoal(
                                details[0],
                                details[1],
                                int.Parse(details[2]),
                                int.Parse(details[3]),
                                int.Parse(details[4])
                            );
                            checklistGoal.SetAmountCompleted(int.Parse(details[5]));
                            return checklistGoal;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating goal from data: {ex.Message}");
            }

            return null;
        }
    }
}
