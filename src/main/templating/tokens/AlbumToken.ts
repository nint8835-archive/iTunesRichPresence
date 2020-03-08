import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

export default class AlbumToken implements Token {
    token = 'album';
    displayName = 'Album';

    render(currentSong: CurrentSong): string {
        return currentSong.Album;
    }
}
