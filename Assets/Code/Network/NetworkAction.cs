using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNetworkAction : MonoBehaviour
{
    #region public interface
    public NetworkSession NetworkSession
    {
        get
        {
            return _networkSession;
        }
    }
    #endregion

    #region virtual interface
    public virtual void OnInitializeNetwork()
    {

    }

    public virtual void OnNetworkJoin(NetworkSession networkSession)
    {

    }

    public virtual void OnNetworkDisconnect(NetworkSession networkSession)
    {

    }

    public virtual void OnNetworkRequestDisconnect(NetworkSession networkSession)
    {

    }
    #endregion

    #region private logic
    NetworkSession _networkSession;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
