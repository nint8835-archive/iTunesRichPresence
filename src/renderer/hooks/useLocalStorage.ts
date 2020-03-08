import * as React from 'react';

// Modified version of useLocalStorage hook from usehooks.com
// https://usehooks.com/useLocalStorage/
export default function useLocalStorage<T>(key: string, initialValue: T): [T, (value: T) => void] {
    const [storedValue, setStoredValue] = React.useState(() => {
        try {
            const item = window.localStorage.getItem(key);
            return item ? JSON.parse(item) : initialValue;
        } catch (error) {
            return initialValue;
        }
    });

    const setValue = (value: T) => {
        const valueToStore = value instanceof Function ? value(storedValue) : value;
        setStoredValue(valueToStore);
        window.localStorage.setItem(key, JSON.stringify(valueToStore));
    };

    return [storedValue, setValue];
}
