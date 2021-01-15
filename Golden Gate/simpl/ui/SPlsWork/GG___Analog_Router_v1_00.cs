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

namespace UserModule_GG___ANALOG_ROUTER_V1_00
{
    public class UserModuleClass_GG___ANALOG_ROUTER_V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> IN;
        Crestron.Logos.SplusObjects.AnalogInput INDEX;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> OUT;
        object IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 15;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 17;
                OUT [ I]  .Value = (ushort) ( INDEX  .UshortValue ) ; 
                __context__.SourceCodeLine = 18;
                _SplusNVRAM.GISTORED [ 1] = (ushort) ( INDEX  .UshortValue ) ; 
                
                
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
            
            __context__.SourceCodeLine = 25;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 27;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)100; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 29;
                OUT [ I]  .Value = (ushort) ( _SplusNVRAM.GISTORED[ 1 ] ) ; 
                __context__.SourceCodeLine = 27;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.GISTORED  = new ushort[ 101 ];
        
        IN = new InOutArray<DigitalInput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            IN[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( IN__DigitalInput__ + i, IN__DigitalInput__, this );
            m_DigitalInputList.Add( IN__DigitalInput__ + i, IN[i+1] );
        }
        
        INDEX = new Crestron.Logos.SplusObjects.AnalogInput( INDEX__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INDEX__AnalogSerialInput__, INDEX );
        
        OUT = new InOutArray<AnalogOutput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( OUT__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( OUT__AnalogSerialOutput__ + i, OUT[i+1] );
        }
        
        
        for( uint i = 0; i < 100; i++ )
            IN[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( IN_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_GG___ANALOG_ROUTER_V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint IN__DigitalInput__ = 0;
    const uint INDEX__AnalogSerialInput__ = 0;
    const uint OUT__AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort [] GISTORED;
            
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
