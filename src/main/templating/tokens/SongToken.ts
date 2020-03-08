import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

/**
 * Token which when rendered will give the current song's name.
 */
export default class SongToken implements Token {
    /**
     * The token to be replaced.
     */
    token = 'song';
    /**
     * The display name for the token toolbox.
     */
    displayName = 'Song';

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string {
        return currentSong.Name;
    }
}
