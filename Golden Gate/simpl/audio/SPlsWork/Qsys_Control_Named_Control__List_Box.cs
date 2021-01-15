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

namespace UserModule_QSYS_CONTROL_NAMED_CONTROL__LIST_BOX
{
    public class UserModuleClass_QSYS_CONTROL_NAMED_CONTROL__LIST_BOX : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput POLL_ENABLE;
        Crestron.Logos.SplusObjects.AnalogInput SELECTITEM;
        Crestron.Logos.SplusObjects.AnalogOutput VALUE_OUT;
        Crestron.Logos.SplusObjects.StringOutput SELECTED_ITEM;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> STRING_OUT;
        UShortParameter CORE_ID;
        StringParameter NAMED_CONTROL;
        ushort GIID = 0;
        CrestronString GSNC;
        ushort GILISTCOUNT = 0;
        QsysControlV3.QsysNamedControl NC;
        public void HANDLERECEIVEDDATA ( object __sender__ /*QsysControlV3.QsysNameControlEvent SENDER */, QsysControlV3.QsysNCDataChangeArgs ARGS ) 
            { 
            QsysNameControlEvent  SENDER  = (QsysNameControlEvent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 44;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.rValue == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 46;
                    SELECTED_ITEM  .UpdateValue ( ARGS . sValue  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 48;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.rValue == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 50;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ARGS.RawValue > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 52;
                            STRING_OUT [ ARGS.iValue]  .UpdateValue ( ARGS . sValue  ) ; 
                            __context__.SourceCodeLine = 53;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GILISTCOUNT != ARGS.RawValue))  ) ) 
                                { 
                                __context__.SourceCodeLine = 55;
                                GILISTCOUNT = (ushort) ( ARGS.RawValue ) ; 
                                __context__.SourceCodeLine = 56;
                                VALUE_OUT  .Value = (ushort) ( ARGS.RawValue ) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 61;
                            Functions.SetArray ( STRING_OUT , "" ) ; 
                            __context__.SourceCodeLine = 62;
                            VALUE_OUT  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 63;
                            GILISTCOUNT = (ushort) ( 0 ) ; 
                            } 
                        
                        } 
                    
                    }
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object POLL_ENABLE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 70;
                NC . Poll = (ushort) ( 1 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object POLL_ENABLE_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 74;
            NC . Poll = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SELECTITEM_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 78;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SELECTITEM  .UshortValue > 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 79;
            NC . ListValue = (short) ( SELECTITEM  .ShortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INITIALIZE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        NC . ListType = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 86;
        NC . ID = (ushort) ( GIID ) ; 
        __context__.SourceCodeLine = 87;
        NC . NameC  =  ( GSNC  )  .ToString() ; 
        __context__.SourceCodeLine = 88;
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
        
        __context__.SourceCodeLine = 95;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 96;
        GIID = (ushort) ( CORE_ID  .Value ) ; 
        __context__.SourceCodeLine = 97;
        GSNC  .UpdateValue ( NAMED_CONTROL  ) ; 
        
        
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
    
    SELECTITEM = new Crestron.Logos.SplusObjects.AnalogInput( SELECTITEM__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SELECTITEM__AnalogSerialInput__, SELECTITEM );
    
    VALUE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( VALUE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VALUE_OUT__AnalogSerialOutput__, VALUE_OUT );
    
    SELECTED_ITEM = new Crestron.Logos.SplusObjects.StringOutput( SELECTED_ITEM__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SELECTED_ITEM__AnalogSerialOutput__, SELECTED_ITEM );
    
    STRING_OUT = new InOutArray<StringOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        STRING_OUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( STRING_OUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( STRING_OUT__AnalogSerialOutput__ + i, STRING_OUT[i+1] );
    }
    
    CORE_ID = new UShortParameter( CORE_ID__Parameter__, this );
    m_ParameterList.Add( CORE_ID__Parameter__, CORE_ID );
    
    NAMED_CONTROL = new StringParameter( NAMED_CONTROL__Parameter__, this );
    m_ParameterList.Add( NAMED_CONTROL__Parameter__, NAMED_CONTROL );
    
    
    POLL_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnPush_0, false ) );
    POLL_ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnRelease_1, false ) );
    SELECTITEM.OnAnalogChange.Add( new InputChangeHandlerWrapper( SELECTITEM_OnChange_2, false ) );
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    NC  = new QsysControlV3.QsysNamedControl();
    
    
}

public UserModuleClass_QSYS_CONTROL_NAMED_CONTROL__LIST_BOX ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint POLL_ENABLE__DigitalInput__ = 1;
const uint SELECTITEM__AnalogSerialInput__ = 0;
const uint VALUE_OUT__AnalogSerialOutput__ = 0;
const uint SELECTED_ITEM__AnalogSerialOutput__ = 1;
const uint STRING_OUT__AnalogSerialOutput__ = 2;
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
