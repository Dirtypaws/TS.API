CREATE TABLE [HangFire].[JobQueue] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [JobId]     INT           NOT NULL,
    [Queue]     NVARCHAR (20) NOT NULL,
    [FetchedAt] DATETIME      NULL,
    CONSTRAINT [PK_HangFire_JobQueue] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_HangFire_JobQueue_QueueAndFetchedAt]
    ON [HangFire].[JobQueue]([Queue] ASC, [FetchedAt] ASC);

