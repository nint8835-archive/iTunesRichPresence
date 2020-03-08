import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

/**
 * Token which when rendered will give the current playlist's name.
 */
export default class PlaylistNameToken implements Token {
    /**
     * The token to be replaced.
     */
    token = 'playlist_name';
    /**
     * The display name for the token toolbox.
     */
    displayName = 'Playlist Name';

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string {
        return currentSong.Playlist.Name;
    }
}
