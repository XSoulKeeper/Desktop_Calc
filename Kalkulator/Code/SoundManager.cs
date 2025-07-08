using System;
using System.Collections.Generic;
using System.Media; // For SoundPlayer
using System.Windows; // For Application.GetResourceStream and MessageBox

namespace Kalkulator
{
    // Define an enum for easier identification of sounds
    public enum SoundType
    {
        ClearButtonSound = 0, // Corresponds to audio1.wav
        EqualsButtonSound = 1 // Corresponds to audio2.wav
        // Add more sound types here as you add more audio files
    }

    public class SoundManager
    {
        private readonly List<SoundPlayer> _audioPlayers;

        public SoundManager()
        {
            _audioPlayers = new List<SoundPlayer>();
            LoadAllSounds();
        }

        /// <summary>
        /// Loads all predefined audio files into the sound players list.
        /// </summary>
        private void LoadAllSounds()
        {
            try
            {
                // Load sound for ClearButton (Index 0 in SoundType enum)
                LoadAndAddSoundPlayer("pack://application:,,,/Kalkulator;component/Resources/audio1.wav");
                // Load sound for EqualsButton (Index 1 in SoundType enum)
                LoadAndAddSoundPlayer("pack://application:,,,/Kalkulator;component/Resources/audio2.wav");

                // If you add more sounds, list them here:
                // LoadAndAddSoundPlayer("pack://application:,,,/Kalkulator;component/Resources/another_sound.wav");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Audio loading error: {ex.Message}\nMake sure files .WAV exists and are set to resources", "Audio error", MessageBoxButton.OK, MessageBoxImage.Error);
                _audioPlayers.Clear(); // Clear the list if any loading fails
            }
        }

        /// <summary>
        /// Loads a WAV file from resources and adds it to the internal list of SoundPlayer instances.
        /// The order of loading here determines the index for the SoundType enum.
        /// </summary>
        /// <param name="resourceUri">The Pack URI of the WAV resource.</param>
        private void LoadAndAddSoundPlayer(string resourceUri)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(Application.GetResourceStream(new Uri(resourceUri, UriKind.Absolute)).Stream);
                player.Load();
                _audioPlayers.Add(player);
            }
            catch (Exception ex)
            {
                // Re-throw the exception so the main LoadAllSounds try-catch can handle it.
                throw new Exception($"Couldn t load sound: {resourceUri}", ex);
            }
        }

        /// <summary>
        /// Plays a sound based on its SoundType identifier.
        /// </summary>
        /// <param name="soundType">The type of sound to play.</param>
        public void PlaySound(SoundType soundType)
        {
            int index = (int)soundType; // Cast the enum to its integer value (index)

            // Ensure the index is valid and a player exists at that index
            if (index >= 0 && index < _audioPlayers.Count && _audioPlayers[index] != null)
            {
                try
                {
                    _audioPlayers[index].Play();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Audio error {soundType}: {ex.Message}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Warning: Audio {soundType} couldn t be located or is out of range.");
            }
        }
    }
}