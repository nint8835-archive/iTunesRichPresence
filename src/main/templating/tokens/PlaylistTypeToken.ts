import { Token } from '../types';
import { CurrentSong, PlaylistKind, PlaylistSpecialKind } from '../../itunes/types';

/**
 * Token which when rendered will give the current playlist's type.
 */
export default class PlaylistTypeToken implements Token {
    /**
     * The token to be replaced.
     */
    token = 'playlist_type';
    /**
     * The display name for the token toolbox.
     */
    displayName = 'PlaylistType';

    /**
     * Render the contents of this token.
     * @param currentSong The currently playing song.
     * @returns The new contents of this token.
     */
    render(currentSong: CurrentSong): string {
        if (
            currentSong.Playlist.Kind === PlaylistKind.ITPlaylistKindUser &&
            currentSong.Playlist.SpecialKind !== PlaylistSpecialKind.ITUserPlaylistSpecialKindMusic
        ) {
            return 'Music';
        }
        return 'Album';
    }
}
