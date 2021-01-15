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

namespace UserModule_GG___STRING_KEYPAD_V1_00
{
    public class UserModuleClass_GG___STRING_KEYPAD_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_0;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_1;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_2;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_3;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_4;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_5;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_6;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_7;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_8;
        Crestron.Logos.SplusObjects.DigitalInput DIGIT_9;
        Crestron.Logos.SplusObjects.DigitalInput DASH;
        Crestron.Logos.SplusObjects.DigitalInput ENTER;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.StringOutput CHANNEL__DOLLAR__;
        CrestronString GSTRING;
        object DIGIT_0_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 12;
                GSTRING  .UpdateValue ( GSTRING + "0"  ) ; 
                __context__.SourceCodeLine = 13;
                CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIGIT_1_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 18;
            GSTRING  .UpdateValue ( GSTRING + "1"  ) ; 
            __context__.SourceCodeLine = 19;
            CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DIGIT_2_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 24;
        GSTRING  .UpdateValue ( GSTRING + "2"  ) ; 
        __context__.SourceCodeLine = 25;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_3_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 30;
        GSTRING  .UpdateValue ( GSTRING + "3"  ) ; 
        __context__.SourceCodeLine = 31;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_4_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 36;
        GSTRING  .UpdateValue ( GSTRING + "4"  ) ; 
        __context__.SourceCodeLine = 37;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_5_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 42;
        GSTRING  .UpdateValue ( GSTRING + "5"  ) ; 
        __context__.SourceCodeLine = 43;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_6_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 48;
        GSTRING  .UpdateValue ( GSTRING + "6"  ) ; 
        __context__.SourceCodeLine = 49;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_7_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 54;
        GSTRING  .UpdateValue ( GSTRING + "7"  ) ; 
        __context__.SourceCodeLine = 55;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_8_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 60;
        GSTRING  .UpdateValue ( GSTRING + "8"  ) ; 
        __context__.SourceCodeLine = 61;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIGIT_9_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 66;
        GSTRING  .UpdateValue ( GSTRING + "9"  ) ; 
        __context__.SourceCodeLine = 67;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DASH_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 72;
        GSTRING  .UpdateValue ( GSTRING + "-"  ) ; 
        __context__.SourceCodeLine = 73;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENTER_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 78;
        Functions.Delay (  (int) ( 100 ) ) ; 
        __context__.SourceCodeLine = 79;
        GSTRING  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 80;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        GSTRING  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 86;
        CHANNEL__DOLLAR__  .UpdateValue ( GSTRING  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 91;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 92;
        GSTRING  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    GSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    
    DIGIT_0 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_0__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_0__DigitalInput__, DIGIT_0 );
    
    DIGIT_1 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_1__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_1__DigitalInput__, DIGIT_1 );
    
    DIGIT_2 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_2__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_2__DigitalInput__, DIGIT_2 );
    
    DIGIT_3 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_3__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_3__DigitalInput__, DIGIT_3 );
    
    DIGIT_4 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_4__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_4__DigitalInput__, DIGIT_4 );
    
    DIGIT_5 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_5__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_5__DigitalInput__, DIGIT_5 );
    
    DIGIT_6 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_6__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_6__DigitalInput__, DIGIT_6 );
    
    DIGIT_7 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_7__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_7__DigitalInput__, DIGIT_7 );
    
    DIGIT_8 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_8__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_8__DigitalInput__, DIGIT_8 );
    
    DIGIT_9 = new Crestron.Logos.SplusObjects.DigitalInput( DIGIT_9__DigitalInput__, this );
    m_DigitalInputList.Add( DIGIT_9__DigitalInput__, DIGIT_9 );
    
    DASH = new Crestron.Logos.SplusObjects.DigitalInput( DASH__DigitalInput__, this );
    m_DigitalInputList.Add( DASH__DigitalInput__, DASH );
    
    ENTER = new Crestron.Logos.SplusObjects.DigitalInput( ENTER__DigitalInput__, this );
    m_DigitalInputList.Add( ENTER__DigitalInput__, ENTER );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    CHANNEL__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CHANNEL__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( CHANNEL__DOLLAR____AnalogSerialOutput__, CHANNEL__DOLLAR__ );
    
    
    DIGIT_0.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_0_OnPush_0, false ) );
    DIGIT_1.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_1_OnPush_1, false ) );
    DIGIT_2.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_2_OnPush_2, false ) );
    DIGIT_3.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_3_OnPush_3, false ) );
    DIGIT_4.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_4_OnPush_4, false ) );
    DIGIT_5.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_5_OnPush_5, false ) );
    DIGIT_6.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_6_OnPush_6, false ) );
    DIGIT_7.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_7_OnPush_7, false ) );
    DIGIT_8.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_8_OnPush_8, false ) );
    DIGIT_9.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIGIT_9_OnPush_9, false ) );
    DASH.OnDigitalPush.Add( new InputChangeHandlerWrapper( DASH_OnPush_10, false ) );
    ENTER.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENTER_OnPush_11, false ) );
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_12, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_GG___STRING_KEYPAD_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DIGIT_0__DigitalInput__ = 0;
const uint DIGIT_1__DigitalInput__ = 1;
const uint DIGIT_2__DigitalInput__ = 2;
const uint DIGIT_3__DigitalInput__ = 3;
const uint DIGIT_4__DigitalInput__ = 4;
const uint DIGIT_5__DigitalInput__ = 5;
const uint DIGIT_6__DigitalInput__ = 6;
const uint DIGIT_7__DigitalInput__ = 7;
const uint DIGIT_8__DigitalInput__ = 8;
const uint DIGIT_9__DigitalInput__ = 9;
const uint DASH__DigitalInput__ = 10;
const uint ENTER__DigitalInput__ = 11;
const uint CLEAR__DigitalInput__ = 12;
const uint CHANNEL__DOLLAR____AnalogSerialOutput__ = 0;

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
