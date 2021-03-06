﻿using LiteNetLib.Utils;

namespace MultiplayerARPG.MMO
{
    public struct UpdateUserCharacterMessage : INetSerializable
    {
        public enum UpdateType : byte
        {
            Add,
            Remove,
            Online,
        }
        public UpdateType type;
        public UserCharacterData data;

        public void Deserialize(NetDataReader reader)
        {
            type = (UpdateType)reader.GetByte();
            data.id = reader.GetString();
            data.userId = reader.GetString();
            if (type == UpdateType.Add || type == UpdateType.Online)
            {
                data.characterName = reader.GetString();
                data.dataId = reader.GetInt();
                data.level = reader.GetShort();
                data.partyId = reader.GetInt();
                data.guildId = reader.GetInt();
            }
            if (type == UpdateType.Online)
            {
                data.currentHp = reader.GetInt();
                data.maxHp = reader.GetInt();
                data.currentMp = reader.GetInt();
                data.maxMp = reader.GetInt();
            }
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((byte)type);
            writer.Put(data.id);
            writer.Put(data.userId);
            if (type == UpdateType.Add || type == UpdateType.Online)
            {
                writer.Put(data.characterName);
                writer.Put(data.dataId);
                writer.Put(data.level);
                writer.Put(data.partyId);
                writer.Put(data.guildId);
            }
            if (type == UpdateType.Online)
            {
                writer.Put(data.currentHp);
                writer.Put(data.maxHp);
                writer.Put(data.currentMp);
                writer.Put(data.maxMp);
            }
        }
    }
}
