import { ITunesBridge, CurrentSong, PlayerState, ITunesBridgeError } from '../types';
import { execPowershellCommand } from './utils';

/**
 * Handles communication with iTunes for Windows machines.
 */
export default class WindowsITunesBridge implements ITunesBridge {
    /**
     * Gets the song currently being played by iTunes.
     * @returns A promise resolving to either the current song, or null if no
     *   song is being played.
     */
    async getCurrentSong(): Promise<CurrentSong | null> {
        const [songJson, songStderr] = await execPowershellCommand(
            '(New-Object  -ComObject iTunes.Application).CurrentTrack | ConvertTo-Json'
        );
        if (songStderr !== '') {
            throw new ITunesBridgeError(
                `Failed to retrieve current song, got stderr of:\n${songStderr}`
            );
        }
        if (songJson === '') {
            return null;
        }
        const song: CurrentSong = JSON.parse(songJson);
        const [playlistJson, playlistStderr] = await execPowershellCommand(
            '(New-Object  -ComObject iTunes.Application).CurrentTrack.Playlist | ConvertTo-Json'
        );
        if (playlistStderr !== '') {
            throw new ITunesBridgeError(
                `Failed to retrieve current playlist, got stderr of:\n${playlistStderr}`
            );
        }
        song.Playlist = JSON.parse(playlistJson);
        return song;
    }

    /**
     * Gets the current position of the player on the current track.
     * @returns The number of seconds the player is into the current track, or
     *   null if no song is being played.
     */
    async getCurrentPosition(): Promise<number | null> {
        const [position, stderr] = await execPowershellCommand(
            '(New-Object  -ComObject iTunes.Application).PlayerPosition'
        );
        if (stderr !== '') {
            throw new ITunesBridgeError(
                `Failed to retrieve current position, got stderr of:\n${stderr}`
            );
        }
        if (position === '') {
            return null;
        }
        return parseInt(position, 10);
    }

    /**
     * Gets the current state of the player.
     * @returns The current playback state of the player.
     */
    async getPlayerState(): Promise<PlayerState> {
        const [state, stderr] = await execPowershellCommand(
            '(New-Object  -ComObject iTunes.Application).PlayerState'
        );
        if (stderr !== '') {
            throw new ITunesBridgeError(
                `Failed to retrieve current state, got stderr of:\n${stderr}`
            );
        }
        return parseInt(state, 10);
    }
}
