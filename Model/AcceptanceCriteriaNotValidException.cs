namespace TestManager.Exceptions;

public class AcceptanceCriteriaNotValidException : Exception
{
    public AcceptanceCriteriaNotValidException(string useCase, string acceptanceCriteria) : base($"The use case {useCase} was not passed the acceptance criteria {acceptanceCriteria}") { }
}
