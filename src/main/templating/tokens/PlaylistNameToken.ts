import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

export default class PlaylistNameToken implements Token {
    token = 'playlist_name';
    displayName = 'Playlist Name';

    render(currentSong: CurrentSong): string {
        return currentSong.Playlist.Name;
    }
}
