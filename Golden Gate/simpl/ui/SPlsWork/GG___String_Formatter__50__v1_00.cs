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

namespace UserModule_GG___STRING_FORMATTER__50__V1_00
{
    public class UserModuleClass_GG___STRING_FORMATTER__50__V1_00 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput FONTSIZE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> IN__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ENABLE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> OUT__DOLLAR__;
        private void FORMAT (  SplusExecutionContext __context__, ushort I ) 
            { 
            
            __context__.SourceCodeLine = 15;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( IN__DOLLAR__[ I ] ) > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 16;
                ENABLE [ I]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 18;
                ENABLE [ I]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 20;
            MakeString ( OUT__DOLLAR__ [ I] , "<FONT size=\u0022{0}\u0022 face=\u0022Arial\u0022 color=\u0022#ffffff\u0022>{1}</FONT>", Functions.ItoA (  (int) ( FONTSIZE  .UshortValue ) ) , IN__DOLLAR__ [ I ] ) ; 
            
            }
            
        object IN__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 27;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 29;
                FORMAT (  __context__ , (ushort)( I )) ; 
                
                
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
            
            __context__.SourceCodeLine = 36;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 38;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 40;
                FORMAT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 38;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        ENABLE = new InOutArray<DigitalOutput>( 50, this );
        for( uint i = 0; i < 50; i++ )
        {
            ENABLE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLE__DigitalOutput__ + i, this );
            m_DigitalOutputList.Add( ENABLE__DigitalOutput__ + i, ENABLE[i+1] );
        }
        
        FONTSIZE = new Crestron.Logos.SplusObjects.AnalogInput( FONTSIZE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( FONTSIZE__AnalogSerialInput__, FONTSIZE );
        
        IN__DOLLAR__ = new InOutArray<StringInput>( 50, this );
        for( uint i = 0; i < 50; i++ )
        {
            IN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR____AnalogSerialInput__, 50, this );
            m_StringInputList.Add( IN__DOLLAR____AnalogSerialInput__ + i, IN__DOLLAR__[i+1] );
        }
        
        OUT__DOLLAR__ = new InOutArray<StringOutput>( 50, this );
        for( uint i = 0; i < 50; i++ )
        {
            OUT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( OUT__DOLLAR____AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( OUT__DOLLAR____AnalogSerialOutput__ + i, OUT__DOLLAR__[i+1] );
        }
        
        
        for( uint i = 0; i < 50; i++ )
            IN__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( IN__DOLLAR___OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_GG___STRING_FORMATTER__50__V1_00 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FONTSIZE__AnalogSerialInput__ = 0;
    const uint IN__DOLLAR____AnalogSerialInput__ = 1;
    const uint ENABLE__DigitalOutput__ = 0;
    const uint OUT__DOLLAR____AnalogSerialOutput__ = 0;
    
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
