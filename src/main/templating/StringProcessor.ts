import * as Mustache from 'mustache';
import { ITunesBridge, CurrentSong } from '../itunes/types';
import getBridge from '../itunes';
import Tokens from './tokens';
import { Token } from './types';

type ViewObject = {
    [token: string]: (() => string) | CurrentSong;
    currentSong: CurrentSong;
};

/**
 * Handles processing of template strings into presence-ready strings.
 */
export default class StringProcessor {
    bridge: ITunesBridge | null;
    tokens: Token[];

    constructor() {
        this.bridge = getBridge();
        this.tokens = Tokens;
    }

    async render(template: string): Promise<string> {
        const currentSong = await this.bridge?.getCurrentSong();
        if (typeof currentSong === 'undefined') {
            return 'Unable to retrieve playback status.';
        }
        if (currentSong === null) {
            return 'No song is currently playing.';
        }
        const view: ViewObject = { currentSong };
        this.tokens.forEach(token => {
            view[token.token] = () => token.render(currentSong);
        });
        return Mustache.render(template, view);
    }
}
