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

namespace UserModule_TAS___NV_VALUES__16_
{
    public class UserModuleClass_TAS___NV_VALUES__16_ : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> IN;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUT;
        object IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 19;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 21;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLE  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 23;
                    _SplusNVRAM.GIVALUE [ I] = (ushort) ( IN[ I ] .UshortValue ) ; 
                    __context__.SourceCodeLine = 24;
                    Trace( "The Value {0:d} was Stored", (ushort)_SplusNVRAM.GIVALUE[ I ]) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        ushort I = 0;
        
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 32;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 34;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)16; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 36;
                OUT [ I]  .Value = (ushort) ( _SplusNVRAM.GIVALUE[ I ] ) ; 
                __context__.SourceCodeLine = 34;
                } 
            
            
            
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
        _SplusNVRAM.GIVALUE  = new ushort[ 17 ];
        
        ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
        m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
        
        IN = new InOutArray<AnalogInput>( 16, this );
        for( uint i = 0; i < 16; i++ )
        {
            IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( IN__AnalogSerialInput__ + i, IN__AnalogSerialInput__, this );
            m_AnalogInputList.Add( IN__AnalogSerialInput__ + i, IN[i+1] );
        }
        
        OUT = new InOutArray<AnalogOutput>( 16, this );
        for( uint i = 0; i < 16; i++ )
        {
            OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUT__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( OUT__AnalogSerialOutput__ + i, OUT[i+1] );
        }
        
        
        for( uint i = 0; i < 16; i++ )
            IN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( IN_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TAS___NV_VALUES__16_ ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint ENABLE__DigitalInput__ = 0;
    const uint IN__AnalogSerialInput__ = 0;
    const uint OUT__AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort [] GIVALUE;
            
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
