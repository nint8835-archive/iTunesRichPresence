import { Token } from '../types';
import { CurrentSong, PlaylistKind, PlaylistSpecialKind } from '../../itunes/types';

export default class PlaylistTypeToken implements Token {
    token = 'playlist_type';
    displayName = 'PlaylistType';

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
