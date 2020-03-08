import { FormGroup, TextInput } from 'carbon-components-react';
import * as React from 'react';
import { PlayerState } from '../../../main/itunes/types';
import useLocalStorage from '../../hooks/useLocalStorage';
import { TokenToolbox } from './TokenToolbox';

type StateConfigEditorProps = {
    playerState: PlayerState;
};

export const StateConfigEditor: React.FunctionComponent<StateConfigEditorProps> = ({
    playerState
}) => {
    const [firstLine, setFirstLine] = useLocalStorage<string>(
        `${PlayerState[playerState]}FirstLine`,
        ''
    );
    const [secondLine, setSecondLine] = useLocalStorage<string>(
        `${PlayerState[playerState]}SecondLine`,
        ''
    );
    const [lastFocusedInput, setLastFocusedInput] = React.useState('FirstLine');
    const focusMap = {
        FirstLine: {
            value: firstLine,
            set: setFirstLine
        },
        SecondLine: {
            value: secondLine,
            set: setSecondLine
        }
    };
    const focusData = lastFocusedInput === 'FirstLine' ? focusMap.FirstLine : focusMap.SecondLine;
    return (
        <>
            <FormGroup legendText="First Line">
                <TextInput
                    labelText=""
                    id={`${PlayerState[playerState]}FirstLine`}
                    value={firstLine}
                    onInput={event => {
                        setFirstLine(event.currentTarget.value);
                    }}
                    invalid={firstLine.length === 0}
                    onFocus={() => {
                        setLastFocusedInput('FirstLine');
                    }}
                />
            </FormGroup>
            <FormGroup legendText="Second Line">
                <TextInput
                    labelText=""
                    id={`${PlayerState[playerState]}SecondLine`}
                    value={secondLine}
                    onInput={event => {
                        setSecondLine(event.currentTarget.value);
                    }}
                    invalid={secondLine.length === 0}
                    onFocus={() => {
                        setLastFocusedInput('SecondLine');
                    }}
                />
            </FormGroup>
            <TokenToolbox lastFocusedText={focusData.value} setLastFocusedText={focusData.set} />
        </>
    );
};
