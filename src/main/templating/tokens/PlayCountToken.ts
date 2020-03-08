import { Token } from '../types';
import { CurrentSong } from '../../itunes/types';

export default class PlayCountToken implements Token {
    token = 'play_count';
    displayName = 'Play Count';

    render(currentSong: CurrentSong): string {
        return currentSong.PlayedCount.toString();
    }
}
