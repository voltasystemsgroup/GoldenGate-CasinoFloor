namespace QsysControlV3;
        // class declarations
         class QsysNameControlEvent;
         class QsysCoreEvent;
         class QsysNamedControl;
         class QsysCore;
         class QsysMain;
         class QsysListBox;
         class QsysNCDataChangeArgs;
         class QsysCoreChangeArgs;
         class QsysParser;
     class QsysNameControlEvent 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( QsysNameControlEvent sender, QsysNCDataChangeArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QsysCoreEvent 
    {
        // class delegates

        // class events
        EventHandler OnCoreChange ( QsysCoreEvent sender, QsysCoreChangeArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QsysNamedControl 
    {
        // class delegates

        // class events
        EventHandler OnDataReceived ( QsysNamedControl sender, QsysNCDataChangeArgs e );

        // class functions
        FUNCTION NamedControlTrigger ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        QsysNameControlEvent NCEvent;
        INTEGER ListType;
        INTEGER ID;
        SIGNED_INTEGER RampTime;
        STRING _Name[];
        SIGNED_INTEGER _dValue;
        SIGNED_INTEGER _rValue;
        STRING _sValue[];
        SIGNED_INTEGER _Value;
        INTEGER _poll;

        // class properties
        STRING NameC[];
        SIGNED_INTEGER dValue;
        SIGNED_INTEGER dValueRamp;
        SIGNED_INTEGER rValue;
        SIGNED_INTEGER rValueRamp;
        STRING sValue[];
        SIGNED_INTEGER Value;
        SIGNED_INTEGER ListValue;
        SIGNED_INTEGER sss;
        SIGNED_INTEGER ssl;
        INTEGER Poll;
    };

     class QsysCore 
    {
        // class delegates
        delegate FUNCTION InitializeStatus ( INTEGER InitValue );

        // class events
        EventHandler OnCorex ( QsysCore sender, QsysCoreChangeArgs e );

        // class functions
        FUNCTION SendData ( STRING Data );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        QsysCoreEvent CoreEvent;
        STRING User[];
        INTEGER Pin;
        STRING ValidRespone[][];
        INTEGER ConnStatus;
        SIGNED_INTEGER init;
        INTEGER ID;
        SIGNED_INTEGER port;
        STRING _address[];

        // class properties
        DelegateProperty InitializeStatus Initialized;
        STRING Address[];
    };

    static class QsysMain 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static INTEGER DebugValue;
        static STRING ProgSlot[];

        // class properties
    };

     class QsysListBox 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Text[];
        STRING Color[];
    };

     class QsysNCDataChangeArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING sValue[];
        SIGNED_INTEGER iValue;
        SIGNED_INTEGER rValue;
        SIGNED_INTEGER RawValue;
    };

     class QsysCoreChangeArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Status;
    };

     class QsysParser 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING rType[];
        STRING rNC[];
        STRING rData[][];
        STRING rDValue[];
        STRING rRValue[];
    };

