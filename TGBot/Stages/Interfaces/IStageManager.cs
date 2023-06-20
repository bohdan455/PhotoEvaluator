namespace TGBot.Stages.Interfaces
{
    public interface IStageManager
    {
        IStage GetStageInstance(int stageId);
    }
}