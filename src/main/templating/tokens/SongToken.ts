import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

export default class SongToken implements Token {
    token = 'song';
    displayName = 'Song';

    render(currentSong: CurrentSong): string {
        return currentSong.Name;
    }
}
