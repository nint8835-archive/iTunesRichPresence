import { ITunesBridge } from './types';
import WindowsITunesBridge from './windows/bridge';

/**
 * Gets the correct iTunes bridge for your platform.
 * @returns The bridge for your platform, or null if no bridge exists.
 */
export default function getBridge(): ITunesBridge | null {
    if (process.platform === 'win32') {
        return new WindowsITunesBridge();
    }
    return null;
}
