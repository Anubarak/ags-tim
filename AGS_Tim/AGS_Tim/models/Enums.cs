namespace AGS_Tim.models
{
    /// <summary> Stellt die Hardware Input Möglichkeiten dar </summary>
    public enum EHWInput
    {
        Keyboard = 0,
        HopScotch = 1
    }

    /// <summary>
    /// Represents the responses when checking an answer
    /// </summary>
    public enum ValidateAnswerResponse
    {
        WrongAnswer = 0,
        CorrectAnswer = 1,
        AnswerComplete = 2

    }
}