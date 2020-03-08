import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

export default class ArtistToken implements Token {
    token = 'artist';
    displayName = 'Artist';

    render(currentSong: CurrentSong): string {
        return currentSong.Artist;
    }
}
