using AkrProtoLib;
using System;
using System.Collections.Generic;

namespace NetworkCore
{
    public class BaseTransaction : ISerializable
    {
        protected NetworkMessage anyMessage;
        protected int typeID;
        protected List<BaseTransactionComponent> componentList = new List<BaseTransactionComponent>();

        public void AddComponent<T>() where T : BaseTransactionComponent, new()
        {
            BaseTransactionComponent transactionComponent = new T();
            componentList.Add(transactionComponent);
        }

        public void AddComponet(BaseTransactionComponent transactionComponent)
        {
            componentList.Add(transactionComponent);
        }

        public T GetComponent<T>() where T : BaseTransactionComponent
        {
            BaseTransactionComponent result = null;

            result = componentList.Find(r => r is T);

            return (T) result;
        }

        public BaseTransactionComponent[] GetAllComponents()
        {
            return componentList.ToArray();
        }

        public string Serilize()
        {
            throw new NotImplementedException();
        }

        public void Parse(string serializedObject)
        {
            throw new NotImplementedException();
        }
    }
}