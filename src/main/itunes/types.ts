/**
 * Represents an interface with which we can interact with iTunes.
 */
// eslint-disable-next-line @typescript-eslint/interface-name-prefix
export interface ITunesBridge {
    /**
     * Gets the song currently being played by iTunes.
     * @returns A promise resolving to either the current song, or null if no
     *   song is being played.
     */
    getCurrentSong(): Promise<CurrentSong | null>;
}

/**
 * Represents the kind of a playlist.
 */
export enum PlaylistKind {
    /**
     * Unknown playlist kind.
     */
    ITPlaylistUnknown,
    /**
     * Library playlist.
     */
    ITPlaylistKindLibrary,
    /**
     * User playlist.
     */
    ITPlaylistKindUser,
    /**
     * CD playlist.
     */
    ITPlaylistKindCD,
    /**
     * Device playlist.
     */
    ITPlaylistKindDevice,
    /**
     * Radio tuner playlist.
     */
    ITPlaylistKindRadioTuner
}

/**
 * Represents the special kind for special playlists.
 */
export enum PlaylistSpecialKind {
    /**
     * No special kind.
     */
    ITUserPlaylistSpecialKindNone,
    /**
     * Purchased Music playlist.
     */
    ITUserPlaylistSpecialKindPurchasedMusic,
    /**
     * Party Shuffle playlist.
     */
    ITUserPlaylistSpecialKindPartyShuffle,
    /**
     * Podcasts playlist.
     */
    ITUserPlaylistSpecialKindPodcasts,
    /**
     * Folder playlist.
     */
    ITUserPlaylistSpecialKindFolder,
    /**
     * Videos playlist.
     */
    ITUserPlaylistSpecialKindVideos,
    /**
     * Music playlist.
     */
    ITUserPlaylistSpecialKindMusic,
    /**
     * Movies playlist.
     */
    ITUserPlaylistSpecialKindMovies,
    /**
     * TV Shows playlist.
     */
    ITUserPlaylistSpecialKindTVShows,
    /**
     * Audiobooks playlist.
     */
    ITUserPlaylistSpecialKindAudiobooks
}

/**
 * Represents a playlist.
 */
export type Playlist = {
    /**
     * The name of this playlist.
     */
    Name: string;
    /**
     * The kind of playlist this playlist is.
     */
    Kind: PlaylistKind;
    /**
     * The duration of this playlist.
     */
    Duration: number;
    /**
     * The duration of this playlist, formatted as a human-readable string.
     */
    Time: string;
    /**
     * The special kind of this playlist.
     */
    SpecialKind?: PlaylistSpecialKind;
};

/**
 * Represents the kind of a track.
 */
export enum TrackKind {
    /**
     * Unknown track kind.
     */
    ITTrackKindUnknown,
    /**
     * File track.
     */
    ITTrackKindFile,
    /**
     * CD track.
     */
    ITTrackKindCD,
    /**
     * URL track.
     */
    ITTrackKindURL,
    /**
     * Device track.
     */
    ITTrackKindDevice,
    /**
     * Shared library track.
     */
    ITTrackKindSharedLibrary
}

/**
 * Represents the song that is currently being played.
 */
export type CurrentSong = {
    /**
     * The name of this track.
     */
    Name: string;
    /**
     * The kind of this track.
     */
    Kind: TrackKind;
    /**
     * The playlist this track is being played from.
     */
    Playlist: Playlist;
    /**
     * The album this track is from.
     */
    Album: string;
    /**
     * The artist of this track.
     */
    Artist: string;
    /**
     * The duration of this track.
     */
    Duration: number;
    /**
     * The finish time of this track.
     */
    Finish: number;
    /**
     * The genre of this track.
     */
    Genre: string | null;
    /**
     * The play count of this track.
     */
    PlayedCount: number;
    /**
     * The start time of this track.
     */
    Start: number;
    /**
     * The length of this track, formatted as a human-readable string.
     */
    Time: string;
    /**
     * The year this track was released.
     */
    Year: number;
    /**
     * The artist of the album this track is on.
     */
    AlbumArtist: string;
};
