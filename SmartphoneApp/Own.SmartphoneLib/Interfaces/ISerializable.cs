namespace Own.SmartphoneLib
{
    public interface ISerializable
    {
        void Serialize(string path, SmartphoneList spList);
        SmartphoneList Deserialize(string path);
    }
}
