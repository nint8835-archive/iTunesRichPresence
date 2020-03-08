import { CurrentSong } from '../itunes/types';

export interface Token {
    token: string;
    displayName: string;
    render(currentSong: CurrentSong): string;
}
