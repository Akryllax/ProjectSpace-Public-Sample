using System;

public class SessionTracker
{
    #region internal classes
    public class SessionStatus
    {

    }
    #endregion

    /// <summary>
    /// Constructor for the SessionTracker. Keeps track of current connectivity generic status, i.e., connected, ingame, not-connected, disconneded, error, etc.
    /// </summary>
    public SessionTracker()
    {

    }


    public readonly SessionStatus sessionStatus = new SessionStatus();
}
