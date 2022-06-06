namespace Kursova.Model
{
    public static class AnswerCalculator
    {
        public static Range? GetAnswer()
        {
            Inequality[] inputs = InequalitiesFactory.Inequalities;
            Range answer = new Range(null, null);
            foreach (var inequality in inputs)
            {
                answer = answer & inequality.Range;
                if (answer.IsNull) break;
            }
            return answer.IsNull?null:answer;
        }
    }
}