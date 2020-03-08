import { exec } from 'child_process';

/**
 * Executes a command with Powershell, returning the result of stdout and stderr.
 * @param command The Powershell command to run.
 * @returns The values of stdout and stderr from running the command.
 */
export function execPowershellCommand(command: string): Promise<[string, string]> {
    return new Promise(resolve => {
        exec(`powershell -Command "& {${command}}"`, (err, stdout, stderr) => {
            resolve([stdout, stderr]);
        });
    });
}
