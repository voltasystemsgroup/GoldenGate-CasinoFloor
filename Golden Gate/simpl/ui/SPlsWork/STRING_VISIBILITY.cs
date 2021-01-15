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

namespace UserModule_STRING_VISIBILITY
{
    public class UserModuleClass_STRING_VISIBILITY : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        InOutArray<Crestron.Logos.SplusObjects.StringInput> STRINGS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VISIBILITY;
        object STRINGS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort STRINGTOCHECK = 0;
                
                
                __context__.SourceCodeLine = 181;
                STRINGTOCHECK = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 183;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STRINGS[ STRINGTOCHECK ] ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 185;
                    VISIBILITY [ STRINGTOCHECK]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 189;
                    VISIBILITY [ STRINGTOCHECK]  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        ushort CYCLE = 0;
        
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 248;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)100; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( CYCLE  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (CYCLE  >= __FN_FORSTART_VAL__1) && (CYCLE  <= __FN_FOREND_VAL__1) ) : ( (CYCLE  <= __FN_FORSTART_VAL__1) && (CYCLE  >= __FN_FOREND_VAL__1) ) ; CYCLE  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 250;
                VISIBILITY [ CYCLE]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 248;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        VISIBILITY = new InOutArray<DigitalOutput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            VISIBILITY[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VISIBILITY__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( VISIBILITY__DigitalOutput__ + i, VISIBILITY[i+1] );
        }
        
        STRINGS = new InOutArray<StringInput>( 100, this );
        for( uint i = 0; i < 100; i++ )
        {
            STRINGS[i+1] = new Crestron.Logos.SplusObjects.StringInput( STRINGS__AnalogSerialInput__ + i, STRINGS__AnalogSerialInput__, 100, this );
            m_StringInputList.Add( STRINGS__AnalogSerialInput__ + i, STRINGS[i+1] );
        }
        
        
        for( uint i = 0; i < 100; i++ )
            STRINGS[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( STRINGS_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_STRING_VISIBILITY ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint STRINGS__AnalogSerialInput__ = 0;
    const uint VISIBILITY__DigitalOutput__ = 0;
    
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
