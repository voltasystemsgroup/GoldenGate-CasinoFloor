using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using QsysControlV3;

namespace UserModule_QSYS_CONTROL_NAMED_CONTROL
{
    public class UserModuleClass_QSYS_CONTROL_NAMED_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput POLL_ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput TRIGGER;
        Crestron.Logos.SplusObjects.AnalogInput VALUE_IN;
        Crestron.Logos.SplusObjects.AnalogInput VALUE_IN_RAMPED;
        Crestron.Logos.SplusObjects.AnalogInput RELATIVE_IN;
        Crestron.Logos.SplusObjects.AnalogInput RELATIVE_IN_RAMPED;
        Crestron.Logos.SplusObjects.AnalogInput RAW_IN;
        Crestron.Logos.SplusObjects.AnalogInput RAMP_TIME;
        Crestron.Logos.SplusObjects.StringInput STRING_IN;
        Crestron.Logos.SplusObjects.AnalogOutput VALUE_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput RELATIVE_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput RAW_OUT;
        Crestron.Logos.SplusObjects.StringOutput STRING_OUT;
        UShortParameter CORE_ID;
        StringParameter NAMED_CONTROL;
        ushort GIID = 0;
        CrestronString GSNC;
        ushort GIRAMP = 0;
        QsysControlV3.QsysNamedControl NC;
        public void HANDLERECEIVEDDATA ( object __sender__ /*QsysControlV3.QsysNameControlEvent SENDER */, QsysControlV3.QsysNCDataChangeArgs ARGS ) 
            { 
            QsysNameControlEvent  SENDER  = (QsysNameControlEvent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 46;
                VALUE_OUT  .Value = (ushort) ( ARGS.iValue ) ; 
                __context__.SourceCodeLine = 47;
                RELATIVE_OUT  .Value = (ushort) ( ARGS.rValue ) ; 
                __context__.SourceCodeLine = 48;
                STRING_OUT  .UpdateValue ( ARGS . sValue  ) ; 
                __context__.SourceCodeLine = 49;
                RAW_OUT  .Value = (ushort) ( ARGS.RawValue ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object RAMP_TIME_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 53;
                GIRAMP = (ushort) ( (RAMP_TIME  .UshortValue / 100) ) ; 
                __context__.SourceCodeLine = 54;
                NC . RampTime = (short) ( GIRAMP ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object POLL_ENABLE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 59;
            NC . Poll = (ushort) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object POLL_ENABLE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 63;
        NC . Poll = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VALUE_IN_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 67;
        NC . dValue = (short) ( VALUE_IN  .ShortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VALUE_IN_RAMPED_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 71;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GIRAMP > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 72;
            NC . dValueRamp = (short) ( VALUE_IN_RAMPED  .ShortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 74;
            NC . dValue = (short) ( VALUE_IN_RAMPED  .ShortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RELATIVE_IN_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 78;
        NC . rValue = (short) ( RELATIVE_IN  .ShortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RELATIVE_IN_RAMPED_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 82;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( GIRAMP > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 83;
            NC . rValueRamp = (short) ( RELATIVE_IN_RAMPED  .ShortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 85;
            NC . rValue = (short) ( RELATIVE_IN_RAMPED  .ShortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RAW_IN_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 89;
        NC . Value = (short) ( RAW_IN  .ShortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STRING_IN_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 95;
        NC . sValue  =  ( STRING_IN  )  .ToString() ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TRIGGER_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 99;
        NC . NamedControlTrigger ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INITIALIZE_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 104;
        NC . ListType = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 105;
        NC . ID = (ushort) ( GIID ) ; 
        __context__.SourceCodeLine = 106;
        NC . NameC  =  ( GSNC  )  .ToString() ; 
        __context__.SourceCodeLine = 107;
        // RegisterEvent( NC , ONDATARECEIVED , HANDLERECEIVEDDATA ) 
        try { g_criticalSection.Enter(); NC .OnDataReceived  += HANDLERECEIVEDDATA; } finally { g_criticalSection.Leave(); }
        ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 114;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 115;
        GIID = (ushort) ( CORE_ID  .Value ) ; 
        __context__.SourceCodeLine = 116;
        GSNC  .UpdateValue ( NAMED_CONTROL  ) ; 
        __context__.SourceCodeLine = 117;
        GIRAMP = (ushort) ( (RAMP_TIME  .UshortValue / 100) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    GSNC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    POLL_ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( POLL_ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_ENABLE__DigitalInput__, POLL_ENABLE );
    
    TRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( TRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( TRIGGER__DigitalInput__, TRIGGER );
    
    VALUE_IN = new Crestron.Logos.SplusObjects.AnalogInput( VALUE_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VALUE_IN__AnalogSerialInput__, VALUE_IN );
    
    VALUE_IN_RAMPED = new Crestron.Logos.SplusObjects.AnalogInput( VALUE_IN_RAMPED__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VALUE_IN_RAMPED__AnalogSerialInput__, VALUE_IN_RAMPED );
    
    RELATIVE_IN = new Crestron.Logos.SplusObjects.AnalogInput( RELATIVE_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RELATIVE_IN__AnalogSerialInput__, RELATIVE_IN );
    
    RELATIVE_IN_RAMPED = new Crestron.Logos.SplusObjects.AnalogInput( RELATIVE_IN_RAMPED__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RELATIVE_IN_RAMPED__AnalogSerialInput__, RELATIVE_IN_RAMPED );
    
    RAW_IN = new Crestron.Logos.SplusObjects.AnalogInput( RAW_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RAW_IN__AnalogSerialInput__, RAW_IN );
    
    RAMP_TIME = new Crestron.Logos.SplusObjects.AnalogInput( RAMP_TIME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RAMP_TIME__AnalogSerialInput__, RAMP_TIME );
    
    VALUE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( VALUE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VALUE_OUT__AnalogSerialOutput__, VALUE_OUT );
    
    RELATIVE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( RELATIVE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RELATIVE_OUT__AnalogSerialOutput__, RELATIVE_OUT );
    
    RAW_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( RAW_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RAW_OUT__AnalogSerialOutput__, RAW_OUT );
    
    STRING_IN = new Crestron.Logos.SplusObjects.StringInput( STRING_IN__AnalogSerialInput__, 200, this );
    m_StringInputList.Add( STRING_IN__AnalogSerialInput__, STRING_IN );
    
    STRING_OUT = new Crestron.Logos.SplusObjects.StringOutput( STRING_OUT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( STRING_OUT__AnalogSerialOutput__, STRING_OUT );
    
    CORE_ID = new UShortParameter( CORE_ID__Parameter__, this );
    m_ParameterList.Add( CORE_ID__Parameter__, CORE_ID );
    
    NAMED_CONTROL = new StringParameter( NAMED_CONTROL__Parameter__, this );
    m_ParameterList.Add( NAMED_CONTROL__Parameter__, NAMED_CONTROL );
    
    
    RAMP_TIME.OnAnalogChange.Add( new InputChangeHandlerWrapper( RAMP_TIME_OnChange_0, false ) );
    POLL_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnPush_1, false ) );
    POLL_ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnRelease_2, false ) );
    VALUE_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( VALUE_IN_OnChange_3, false ) );
    VALUE_IN_RAMPED.OnAnalogChange.Add( new InputChangeHandlerWrapper( VALUE_IN_RAMPED_OnChange_4, false ) );
    RELATIVE_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( RELATIVE_IN_OnChange_5, false ) );
    RELATIVE_IN_RAMPED.OnAnalogChange.Add( new InputChangeHandlerWrapper( RELATIVE_IN_RAMPED_OnChange_6, false ) );
    RAW_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( RAW_IN_OnChange_7, false ) );
    STRING_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( STRING_IN_OnChange_8, false ) );
    TRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( TRIGGER_OnPush_9, false ) );
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_10, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    NC  = new QsysControlV3.QsysNamedControl();
    
    
}

public UserModuleClass_QSYS_CONTROL_NAMED_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint POLL_ENABLE__DigitalInput__ = 1;
const uint TRIGGER__DigitalInput__ = 2;
const uint VALUE_IN__AnalogSerialInput__ = 0;
const uint VALUE_IN_RAMPED__AnalogSerialInput__ = 1;
const uint RELATIVE_IN__AnalogSerialInput__ = 2;
const uint RELATIVE_IN_RAMPED__AnalogSerialInput__ = 3;
const uint RAW_IN__AnalogSerialInput__ = 4;
const uint RAMP_TIME__AnalogSerialInput__ = 5;
const uint STRING_IN__AnalogSerialInput__ = 6;
const uint VALUE_OUT__AnalogSerialOutput__ = 0;
const uint RELATIVE_OUT__AnalogSerialOutput__ = 1;
const uint RAW_OUT__AnalogSerialOutput__ = 2;
const uint STRING_OUT__AnalogSerialOutput__ = 3;
const uint CORE_ID__Parameter__ = 10;
const uint NAMED_CONTROL__Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
