namespace Own.SmartphoneLib
{
    interface ISerializable
    {
        void Serialize(string path);
        void Deserialize(string path);
    }
}
