using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
#endif
using System.Text;
using System.Windows.Forms;

namespace Flywire_WinForm
{
#if SWIG
    public class SoundEngine
    {
        CEngineWrapper engine;
        public SoundEngine()
        {
            engine = new CEngineWrapper();
        }

        internal Sound Play2D(string FilePath, bool playLooped = false, bool startPaused = false)
        {
            return new Sound(engine.PlayFile(FilePath));
        }

        internal Source AddSoundSourceFromFile(string FilePath)
        {
            try
            {
                return new Source(engine.LoadFile(FilePath));
            }
            catch (Exception e)
            {
                Exception inner = e;
                MessageBox.Show(inner.ToString());
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                    MessageBox.Show(inner.ToString());
                }
                throw inner;
                //Exception ex = SwigEnginePINVOKE.SWIGPendingException.Retrieve();
                //throw ex;
            }
            
        }
    }
    public class Sound
    {
        CSoundWrapper sound;
        public Sound(CSoundWrapper sound)
        {
            this.sound = sound;
        }

        internal void Stop()
        {
            sound.Stop();
        }

        public uint PlayPosition 
        { 
            get
            {
                return sound.getPlayPosition();
            }
        }

        public uint PlayLength 
        { 
            get 
            { 
                return sound.getPlayLength(); 
            } 
        }
    }
    public class Source
    {
        CSourceWrapper source;
        public Source(CSourceWrapper source)
        {
            this.source = source;
        }

        public uint PlayLength 
        { 
            get  
            {
                return source.getPlayLength();
            } 
        }
    }
    // TODO: Add to c++ wrapper
    interface SoundStopEvent
    {
        void OnSoundStopped(Sound sound, StopEventCause reason, object userData);
    }

    enum StopEventCause
    {
        SoundStoppedBySourceRemoval,            // The sound was stopped because its sound source was removed or the engine was shut down 
        SoundStoppedByUser,                     // The sound was stopped because the user called ISound::stop(). 
        SoundFinishedPlaying                    // The sound finished playing. 

        // c++ library equivalents
        // ESEC_SOUND_FINISHED_PLAYING          // The sound stop event was fired because the sound finished playing. 
        // ESEC_SOUND_STOPPED_BY_USER           // The sound stop event was fired because the sound was stopped by the user, calling ISound::stop().
        // ESEC_SOUND_STOPPED_BY_SOURCE_REMOVAL // The sound stop event was fired because the source of the sound was removed, for example because irrKlang was shut down or the user called ISoundEngine::removeSoundSource(). 
    }
#elif NO_ENGINE
    public class SoundEngine
    {
        public SoundEngine()
        {
           
        }

        internal Sound Play2D(string FilePath, bool playLooped = false, bool startPaused = false)
        {
            return new Sound();
        }

        internal Source AddSoundSourceFromFile(string FilePath)
        {
            return new Source();
        }
    }
    public class Sound
    {
        public Sound()
        {
        }

        internal void Stop()
        {

        }

        public uint PlayPosition
        {
            get
            {
                return 0;
            }
        }

        public uint PlayLength
        {
            get
            {
                return 0;
            }
        }

        public void setSoundStopEventReceiver(SoundStopEvent receiver)
        {

        }
    }
    public class Source
    {
        public Source()
        {

        }

        public uint PlayLength
        {
            get
            {
                return 0;
            }
        }
    }
    // TODO: Add to c++ wrapper
    public interface SoundStopEvent
    {
        void OnSoundStopped(Sound sound, StopEventCause reason, object userData);
    }

    public enum StopEventCause
    {
        SoundStoppedBySourceRemoval,            // The sound was stopped because its sound source was removed or the engine was shut down 
        SoundStoppedByUser,                     // The sound was stopped because the user called ISound::stop(). 
        SoundFinishedPlaying                    // The sound finished playing. 

        // c++ library equivalents
        // ESEC_SOUND_FINISHED_PLAYING          // The sound stop event was fired because the sound finished playing. 
        // ESEC_SOUND_STOPPED_BY_USER           // The sound stop event was fired because the sound was stopped by the user, calling ISound::stop().
        // ESEC_SOUND_STOPPED_BY_SOURCE_REMOVAL // The sound stop event was fired because the source of the sound was removed, for example because irrKlang was shut down or the user called ISoundEngine::removeSoundSource(). 
    }
#endif
}
