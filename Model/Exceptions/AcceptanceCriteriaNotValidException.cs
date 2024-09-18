namespace ExceptionManager.Model;

public class AcceptanceCriteriaNotValidException(string useCase, string acceptanceCriteria)
    : Exception($"The use case {useCase} was not passed the acceptance criteria {acceptanceCriteria}");
