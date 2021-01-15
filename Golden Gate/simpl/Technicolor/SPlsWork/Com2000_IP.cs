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

namespace UserModule_COM2000_IP
{
    public class UserModuleClass_COM2000_IP : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput COM2000_POLL;
        StringParameter CHASSIS_IP_ADDRESS;
        InOutArray<StringParameter> CARD_IP_ADDRESS;
        InOutArray<StringParameter> TUNER_IP_ADDRESS;
        SplusTcpClient CLIENTTCP;
        CrestronString TCPCOMMAND;
        CrestronString STRCHANNELNAME;
        CrestronString STRCHANNELNUMBER;
        ushort NCURRENT_TUNER = 0;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> DIRECTV_DIRECT_TUNE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DIRECTV_CHANNEL_INFO;
        object CLIENTTCP_OnSocketConnect_0 ( Object __Info__ )
        
            { 
            SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
                
                __context__.SourceCodeLine = 55;
                Trace( "Com2000 Tx: {0}\r", TCPCOMMAND ) ; 
                __context__.SourceCodeLine = 56;
                Functions.SocketSend ( CLIENTTCP , TCPCOMMAND ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SocketInfo__ ); }
            return this;
            
        }
        
    object CLIENTTCP_OnSocketReceive_1 ( Object __Info__ )
    
        { 
        SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
            CrestronString STRSEGMENT;
            STRSEGMENT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8192, this );
            
            CrestronString STRTRASH;
            STRTRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8192, this );
            
            CrestronString STRSEARCH_SEGMENT;
            STRSEARCH_SEGMENT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            CrestronString STRTEMP_CHANNEL;
            STRTEMP_CHANNEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
            
            
            __context__.SourceCodeLine = 66;
            Trace( "Com2000 Rx: {0}\r", CLIENTTCP .  SocketRxBuf ) ; 
            __context__.SourceCodeLine = 68;
            if ( Functions.TestForTrue  ( ( Functions.Find( "</body></html>" , CLIENTTCP.SocketRxBuf ))  ) ) 
                { 
                __context__.SourceCodeLine = 70;
                STRSEGMENT  .UpdateValue ( Functions.Gather ( "</body></html>" , CLIENTTCP .  SocketRxBuf , 500)  ) ; 
                __context__.SourceCodeLine = 72;
                if ( Functions.TestForTrue  ( ( Functions.Find( "<td>SNR</td><td>Strength</td></tr>" , STRSEGMENT ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 74;
                    STRTRASH  .UpdateValue ( Functions.Remove ( "<td>SNR</td><td>Strength</td></tr>" , STRSEGMENT )  ) ; 
                    __context__.SourceCodeLine = 75;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)48; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( NCURRENT_TUNER  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NCURRENT_TUNER  >= __FN_FORSTART_VAL__1) && (NCURRENT_TUNER  <= __FN_FOREND_VAL__1) ) : ( (NCURRENT_TUNER  <= __FN_FORSTART_VAL__1) && (NCURRENT_TUNER  >= __FN_FOREND_VAL__1) ) ; NCURRENT_TUNER  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 77;
                        MakeString ( STRSEARCH_SEGMENT , "<td>{0}</td>", TUNER_IP_ADDRESS [ NCURRENT_TUNER ] ) ; 
                        __context__.SourceCodeLine = 79;
                        if ( Functions.TestForTrue  ( ( Functions.Find( STRSEARCH_SEGMENT , STRSEGMENT ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 81;
                            STRTRASH  .UpdateValue ( Functions.Remove ( "tune=" , STRSEGMENT )  ) ; 
                            __context__.SourceCodeLine = 82;
                            STRTRASH  .UpdateValue ( Functions.Remove ( "\u0027>" , STRSEGMENT )  ) ; 
                            __context__.SourceCodeLine = 83;
                            STRTEMP_CHANNEL  .UpdateValue ( Functions.Remove ( "</a>" , STRSEGMENT )  ) ; 
                            __context__.SourceCodeLine = 84;
                            STRTEMP_CHANNEL  .UpdateValue ( Functions.Left ( STRTEMP_CHANNEL ,  (int) ( (Functions.Length( STRTEMP_CHANNEL ) - 4) ) )  ) ; 
                            __context__.SourceCodeLine = 86;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STRTEMP_CHANNEL ) >= 6 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 87;
                                DIRECTV_CHANNEL_INFO [ NCURRENT_TUNER]  .UpdateValue ( STRTEMP_CHANNEL  ) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 89;
                                DIRECTV_CHANNEL_INFO [ NCURRENT_TUNER]  .UpdateValue ( "Error"  ) ; 
                                }
                            
                            } 
                        
                        __context__.SourceCodeLine = 75;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 94;
                Functions.ClearBuffer ( CLIENTTCP .  SocketRxBuf ) ; 
                __context__.SourceCodeLine = 95;
                Functions.SocketDisconnectClient ( CLIENTTCP ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SocketInfo__ ); }
        return this;
        
    }
    
object DIRECTV_DIRECT_TUNE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort NCURRENT_STREAM = 0;
        
        ushort NCURRENT_CARD = 0;
        
        ushort NCURRENT_TUNER = 0;
        
        ushort NMAJOR = 0;
        
        ushort NMINOR = 0;
        
        CrestronString STRSTATION;
        STRSTATION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 109;
        NCURRENT_STREAM = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 111;
        if ( Functions.TestForTrue  ( ( Mod( NCURRENT_STREAM , 8 ))  ) ) 
            {
            __context__.SourceCodeLine = 112;
            NCURRENT_CARD = (ushort) ( ((NCURRENT_STREAM / 8) + 1) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 114;
            NCURRENT_CARD = (ushort) ( (NCURRENT_STREAM / 8) ) ; 
            }
        
        __context__.SourceCodeLine = 116;
        if ( Functions.TestForTrue  ( ( Mod( NCURRENT_STREAM , 8 ))  ) ) 
            {
            __context__.SourceCodeLine = 117;
            NCURRENT_TUNER = (ushort) ( Mod( NCURRENT_STREAM , 8 ) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 119;
            NCURRENT_TUNER = (ushort) ( 8 ) ; 
            }
        
        __context__.SourceCodeLine = 121;
        if ( Functions.TestForTrue  ( ( Functions.Length( DIRECTV_DIRECT_TUNE[ NCURRENT_STREAM ] ))  ) ) 
            { 
            __context__.SourceCodeLine = 123;
            STRSTATION  .UpdateValue ( DIRECTV_DIRECT_TUNE [ NCURRENT_STREAM ]  ) ; 
            __context__.SourceCodeLine = 125;
            if ( Functions.TestForTrue  ( ( Functions.Find( "-" , STRSTATION ))  ) ) 
                { 
                __context__.SourceCodeLine = 127;
                NMAJOR = (ushort) ( Functions.Atoi( Functions.Remove( "-" , STRSTATION ) ) ) ; 
                __context__.SourceCodeLine = 128;
                NMINOR = (ushort) ( Functions.Atoi( STRSTATION ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 132;
                NMAJOR = (ushort) ( Functions.Atoi( STRSTATION ) ) ; 
                __context__.SourceCodeLine = 133;
                NMINOR = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 136;
            MakeString ( TCPCOMMAND , "GET /cgi-bin/webcmd?screen=TuneCard&cardIp={0}&tuner={1}&ip={2}&port={3}&protocol=0&channelObjectId=0&majorNum={4}&minorNum={5}&streamId=111&securityMode=0&persistent=1 HTTP/1.1\u000D\u000A\u000D\u000A", CARD_IP_ADDRESS [ NCURRENT_CARD ] , Functions.ItoA (  (int) ( NCURRENT_TUNER ) ) , TUNER_IP_ADDRESS [ NCURRENT_STREAM ] , Functions.ItoA (  (int) ( (NCURRENT_STREAM + 1001) ) ) , Functions.ItoA (  (int) ( NMAJOR ) ) , Functions.ItoA (  (int) ( NMINOR ) ) ) ; 
            __context__.SourceCodeLine = 137;
            Functions.SocketConnectClient ( CLIENTTCP , CHASSIS_IP_ADDRESS ,  (ushort) ( 80 ) ,  (ushort) ( 0 ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object COM2000_POLL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 144;
        MakeString ( TCPCOMMAND , "GET /cgi-bin/webcmd?screen=discover HTTP/1.1\u000D\u000A\u000D\u000A") ; 
        __context__.SourceCodeLine = 145;
        Functions.SocketConnectClient ( CLIENTTCP , CHASSIS_IP_ADDRESS ,  (ushort) ( 80 ) ,  (ushort) ( 0 ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    TCPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
    STRCHANNELNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    STRCHANNELNUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    CLIENTTCP  = new SplusTcpClient ( 8192, this );
    
    COM2000_POLL = new Crestron.Logos.SplusObjects.DigitalInput( COM2000_POLL__DigitalInput__, this );
    m_DigitalInputList.Add( COM2000_POLL__DigitalInput__, COM2000_POLL );
    
    DIRECTV_DIRECT_TUNE = new InOutArray<StringInput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        DIRECTV_DIRECT_TUNE[i+1] = new Crestron.Logos.SplusObjects.StringInput( DIRECTV_DIRECT_TUNE__AnalogSerialInput__ + i, DIRECTV_DIRECT_TUNE__AnalogSerialInput__, 16, this );
        m_StringInputList.Add( DIRECTV_DIRECT_TUNE__AnalogSerialInput__ + i, DIRECTV_DIRECT_TUNE[i+1] );
    }
    
    DIRECTV_CHANNEL_INFO = new InOutArray<StringOutput>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        DIRECTV_CHANNEL_INFO[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DIRECTV_CHANNEL_INFO__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( DIRECTV_CHANNEL_INFO__AnalogSerialOutput__ + i, DIRECTV_CHANNEL_INFO[i+1] );
    }
    
    CHASSIS_IP_ADDRESS = new StringParameter( CHASSIS_IP_ADDRESS__Parameter__, this );
    m_ParameterList.Add( CHASSIS_IP_ADDRESS__Parameter__, CHASSIS_IP_ADDRESS );
    
    CARD_IP_ADDRESS = new InOutArray<StringParameter>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        CARD_IP_ADDRESS[i+1] = new StringParameter( CARD_IP_ADDRESS__Parameter__ + i, CARD_IP_ADDRESS__Parameter__, this );
        m_ParameterList.Add( CARD_IP_ADDRESS__Parameter__ + i, CARD_IP_ADDRESS[i+1] );
    }
    
    TUNER_IP_ADDRESS = new InOutArray<StringParameter>( 48, this );
    for( uint i = 0; i < 48; i++ )
    {
        TUNER_IP_ADDRESS[i+1] = new StringParameter( TUNER_IP_ADDRESS__Parameter__ + i, TUNER_IP_ADDRESS__Parameter__, this );
        m_ParameterList.Add( TUNER_IP_ADDRESS__Parameter__ + i, TUNER_IP_ADDRESS[i+1] );
    }
    
    
    CLIENTTCP.OnSocketConnect.Add( new SocketHandlerWrapper( CLIENTTCP_OnSocketConnect_0, false ) );
    CLIENTTCP.OnSocketReceive.Add( new SocketHandlerWrapper( CLIENTTCP_OnSocketReceive_1, false ) );
    for( uint i = 0; i < 48; i++ )
        DIRECTV_DIRECT_TUNE[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( DIRECTV_DIRECT_TUNE_OnChange_2, false ) );
        
    COM2000_POLL.OnDigitalPush.Add( new InputChangeHandlerWrapper( COM2000_POLL_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_COM2000_IP ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint COM2000_POLL__DigitalInput__ = 0;
const uint CHASSIS_IP_ADDRESS__Parameter__ = 10;
const uint CARD_IP_ADDRESS__Parameter__ = 11;
const uint TUNER_IP_ADDRESS__Parameter__ = 17;
const uint DIRECTV_DIRECT_TUNE__AnalogSerialInput__ = 0;
const uint DIRECTV_CHANNEL_INFO__AnalogSerialOutput__ = 0;

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
