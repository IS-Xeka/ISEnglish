﻿namespace ISEnglishMVC.Contracts.Words
{
    public record WordsResponse(
        Guid Id,
        string RusTitle,
        string EngTitle,
        string Transcription,
        string CategoryName
        );

    public record WordsRequest(
        string RusTitle,
        string EngTitle,
        string Transcription,
        string CategoryName
        );

}
