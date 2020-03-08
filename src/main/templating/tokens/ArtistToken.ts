import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

/**
 * Token which when rendered will give the current song's artist's name.
 */
export default class ArtistToken implements Token {
    /**
     * The token to be replaced.
     */
    token = 'artist';
    /**
     * The display name for the token toolbox.
     */
    displayName = 'Artist';

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string {
        return currentSong.Artist;
    }
}
