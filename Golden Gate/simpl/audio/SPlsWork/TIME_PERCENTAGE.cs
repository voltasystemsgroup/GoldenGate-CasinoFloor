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

namespace UserModule_TIME_PERCENTAGE
{
    public class UserModuleClass_TIME_PERCENTAGE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput CURRENT_TIME;
        Crestron.Logos.SplusObjects.AnalogInput REMAINING_TIME;
        Crestron.Logos.SplusObjects.AnalogOutput TIME_PERCENTAGE;
        object REMAINING_TIME_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort TOTAL_TIME = 0;
                ushort MULTIPLIER = 0;
                
                
                __context__.SourceCodeLine = 182;
                TOTAL_TIME = (ushort) ( (REMAINING_TIME  .UshortValue + CURRENT_TIME  .UshortValue) ) ; 
                __context__.SourceCodeLine = 184;
                MULTIPLIER = (ushort) ( (65535 / TOTAL_TIME) ) ; 
                __context__.SourceCodeLine = 186;
                TIME_PERCENTAGE  .Value = (ushort) ( (CURRENT_TIME  .UshortValue * MULTIPLIER) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CURRENT_TIME = new Crestron.Logos.SplusObjects.AnalogInput( CURRENT_TIME__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CURRENT_TIME__AnalogSerialInput__, CURRENT_TIME );
        
        REMAINING_TIME = new Crestron.Logos.SplusObjects.AnalogInput( REMAINING_TIME__AnalogSerialInput__, this );
        m_AnalogInputList.Add( REMAINING_TIME__AnalogSerialInput__, REMAINING_TIME );
        
        TIME_PERCENTAGE = new Crestron.Logos.SplusObjects.AnalogOutput( TIME_PERCENTAGE__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( TIME_PERCENTAGE__AnalogSerialOutput__, TIME_PERCENTAGE );
        
        
        REMAINING_TIME.OnAnalogChange.Add( new InputChangeHandlerWrapper( REMAINING_TIME_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TIME_PERCENTAGE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CURRENT_TIME__AnalogSerialInput__ = 0;
    const uint REMAINING_TIME__AnalogSerialInput__ = 1;
    const uint TIME_PERCENTAGE__AnalogSerialOutput__ = 0;
    
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
