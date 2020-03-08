import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

/**
 * Token which when rendered will give the current song's play count.
 */
export default class PlayCountToken implements Token {
    /**
     * The token to be replaced.
     */
    token = 'play_count';
    /**
     * The display name for the token toolbox.
     */
    displayName = 'Play Count';

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string {
        return currentSong.PlayedCount.toString();
    }
}
