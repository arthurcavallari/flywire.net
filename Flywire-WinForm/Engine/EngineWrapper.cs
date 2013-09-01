#if NOT_NET4
extern alias NET2;
#else
extern alias NET4;
#endif
using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;
using System.Runtime.InteropServices;


/* START SoundEngine definition */

// any changes here, make sure to update PlayControl.cs!
#if !SWIG && NOT_NET4
using SoundEngine = NET2.IrrKlang.ISoundEngine;
using Sound = NET2.IrrKlang.ISound;
using Source = NET2.IrrKlang.ISoundSource;
using SoundStopEvent = NET2.IrrKlang.ISoundStopEventReceiver;
using StopEventCause = NET2.IrrKlang.StopEventCause;
#elif !SWIG && !NOT_NET4 && !NO_ENGINE
using SoundEngine = NET4.IrrKlang.ISoundEngine;
using Sound = NET4.IrrKlang.ISound;
using Source = NET4.IrrKlang.ISoundSource;
using SoundStopEvent = NET4.IrrKlang.ISoundStopEventReceiver;
using StopEventCause = NET4.IrrKlang.StopEventCause;
#elif NO_ENGINE

#endif
/* END SoundEngine definition */


namespace Flywire_WinForm
{
    // This will allow for quick change of sound engine, etc.. 
    public class EngineWrapper
    {
        SoundEngine engine;

        public EngineWrapper()
        {
            engine = new SoundEngine();
        }

        public SoundWrapper PlayFile(string FilePath)
        {
            return new SoundWrapper(engine.Play2D(FilePath));
        }

        public SourceWrapper LoadFile(string FilePath)
        {
            return new SourceWrapper(engine.AddSoundSourceFromFile(FilePath));
        }
    }

    public class SoundWrapper
    {
        Sound sound;
        public SoundWrapper(Sound sound)
        {
            this.sound = sound;
        }

        public void Stop()
        {
            sound.Stop();
        }

        public uint PlayPosition
        {
            get
            {
                return sound.PlayPosition;
            }
        }

        public uint PlayLength
        {
            get
            {
                return sound.PlayLength;
            }
        }

        // TODO: Add to c++ wrapper
        public void setSoundStopEventReceiver(SoundStopEvent receiver)
        {
            sound.setSoundStopEventReceiver(receiver);
        }
        
    }

    public class SourceWrapper
    {
        Source source;
        public SourceWrapper(Source source)
        {
            this.source = source;
        }

        public uint PlayLength
        {
            get
            {
                return source.PlayLength;
            }
        }
    }
    /*
    public class SoundStopEventArgs : EventArgs
    {
        // Constructor
        public SoundStopEventArgs(Sound sound, StopEventCause reason, object userData)
        {
            this.sound = sound;
            this.reason = reason;
            this.userData = userData;
        }

        // Properties
        public Sound sound { get; set; }
        public StopEventCause reason { get; set; }
        public object userData { get; set; }
    }

    public delegate void SoundReceiverEventHandler(object sender, SoundStopEventArgs e);
    */

    
}
