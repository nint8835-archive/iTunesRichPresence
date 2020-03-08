import { CurrentSong } from '../itunes/types';

/**
 * Represents a token which can appear in a presence config.
 */
export interface Token {
    /**
     * The token to be replaced.
     */
    token: string;
    /**
     * The display name for the token toolbox.
     */
    displayName: string;

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string;
}
