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

namespace UserModule_GG___TEXT_ROUTER__50__V1_00
{
    public class UserModuleClass_GG___TEXT_ROUTER__50__V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput INDEX;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> IN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput OUT__DOLLAR__;
        object INDEX_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 14;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INDEX  .UshortValue > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 16;
                    OUT__DOLLAR__  .UpdateValue ( IN__DOLLAR__ [ INDEX  .UshortValue ]  ) ; 
                    __context__.SourceCodeLine = 17;
                    _SplusNVRAM.GSSTRING  .UpdateValue ( IN__DOLLAR__ [ INDEX  .UshortValue ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 20;
                    OUT__DOLLAR__  .UpdateValue ( "Error"  ) ; 
                    }
                
                
                
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
            
            __context__.SourceCodeLine = 25;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 26;
            OUT__DOLLAR__  .UpdateValue ( _SplusNVRAM.GSSTRING  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        _SplusNVRAM.GSSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        INDEX = new Crestron.Logos.SplusObjects.AnalogInput( INDEX__AnalogSerialInput__, this );
        m_AnalogInputList.Add( INDEX__AnalogSerialInput__, INDEX );
        
        IN__DOLLAR__ = new InOutArray<StringInput>( 50, this );
        for( uint i = 0; i < 50; i++ )
        {
            IN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR____AnalogSerialInput__, 25, this );
            m_StringInputList.Add( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR__[i+1] );
        }
        
        OUT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( OUT__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( OUT__DOLLAR____AnalogSerialOutput__, OUT__DOLLAR__ );
        
        
        INDEX.OnAnalogChange.Add( new InputChangeHandlerWrapper( INDEX_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_GG___TEXT_ROUTER__50__V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint INDEX__AnalogSerialInput__ = 0;
    const uint IN__DOLLAR____AnalogSerialInput__ = 1;
    const uint OUT__DOLLAR____AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public CrestronString GSSTRING;
            
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
