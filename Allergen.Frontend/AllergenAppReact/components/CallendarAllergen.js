import * as React from 'react';
import {View, Text, StyleSheet} from 'react-native';
import styled from 'styled-components';
import styles from './styles/CallendarScreenStyle';

class CallendarAllergen extends React.Component {
        constructor(props) {
            super(props);
            this.state = {
                isMounted: false
            }
        }     

        polluteLevel() {
            switch(this.props.polluteLevel) {      
              case 1:   return <PolluteLevelLow>Niskie</PolluteLevelLow>;
              case 2:   return <PolluteLevelMedium>Średnie</PolluteLevelMedium>;
              case 3:   return <PolluteLevelHigh>Wysokie</PolluteLevelHigh>;
              default:  return <PolluteLevelUnknown>Brak</PolluteLevelUnknown>;
            }
          }

        render() {                  
            return(
                <View style={styles.container}>
                    <Text style={styles.label}>{this.props.allergenName}</Text>
                    {this.polluteLevel()}
                </View>
            )
        }
}

const PolluteLevelLow = styled(Text)`
color: 'rgba(60, 179, 113,1)';
`
const PolluteLevelMedium = styled(Text)`
color: 'rgba(255, 165, 0,1)';
`;
const PolluteLevelHigh = styled(Text)`
color: 'rgba(266, 64, 64,1)';
`;
const PolluteLevelUnknown = styled(Text)`
color: 'rgba(40, 40, 40,1)';
`;

export default CallendarAllergen;