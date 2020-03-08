import * as Mustache from 'mustache';
import { ITunesBridge, CurrentSong } from '../itunes/types';
import getBridge from '../itunes';
import Tokens from './tokens';
import { Token } from './types';

/**
 * Represents the view that will be given to Mustache when rendering.
 */
type ViewObject = {
    [token: string]: (() => string) | CurrentSong;
    currentSong: CurrentSong;
};

/**
 * Handles processing of template strings into presence-ready strings.
 */
export default class StringProcessor {
    /**
     * The bridge instance that will be used to interact with iTunes.
     */
    bridge: ITunesBridge | null;
    /**
     * The list of tokens that will be available to users.
     */
    tokens: Token[];

    constructor() {
        this.bridge = getBridge();
        this.tokens = Tokens;
    }

    /**
     * Render a template string into a presence-ready string.
     * @param template The template string to render.
     * @returns The rendered string.
     */
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
