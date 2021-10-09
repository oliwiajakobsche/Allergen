import * as React from 'react';
import {View, Text, ActivityIndicator, Switch, ListItem, StyleSheet} from 'react-native';
import { GetUserCallendrUrl, UserId } from '../ApiUrls';
import CallendarAllergen from './CallendarAllergen';
import styled from 'styled-components/native';
import moment from 'moment';
import styles from './styles/CallendarScreenStyle';

class CallendarScreen extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          isLoading: true,
          dataSource: null,
          date: new Date(),
          rerender: false
        }
      }

      componentDidMount(){        
        this.focusListener = this.props.navigation.addListener('focus', () => { 
                console.log('focus is called'); 
               //your logic here.
               console.log('state: ' + this.state.rerender); 
               this.state.isLoading=true;
               this.getUserAllergensPolluteFromApi();
               
        });
        return this.getUserAllergensPolluteFromApi();
      }

      render() {
        console.log('rennnder'); 
        if(this.state.isLoading)
        {
          return (
          <View>
            <ActivityIndicator/>
          </View>
          );
        }
        else {         
          let allergens = this.state.dataSource.map((val, key) => {
            return (
            <View key={key}>
                 <CallendarAllergen allergenName={val.allergenName} polluteLevel={val.impactLevel}></CallendarAllergen>
            </View>
            )
          })
        return(
          <View>
              <CalendarPicker>
                  <Text style={styles.arrowLeft}> {"<"}  </Text>
                    <Text style={styles.date}>{ moment(new Date()).format('YYYY-MM-DD') }</Text>   
                   <Text style={styles.arrowRight}> {">"}  </Text>
              </CalendarPicker>
              
                {allergens}
          </View>
        )
        }
      }
      
      getUserAllergensPolluteFromApi () {        
        let date = moment(new Date()).format('YYYY-MM-DD')
        let url = GetUserCallendrUrl + UserId.toString() + "/" + date;

        console.log(url);
        
        return fetch(url, {method: "GET",
        headers: {
          'Accept': 'application/json, text/plain, */*',
          'Content-Type': 'application/json'
        },})
        .then((response)=>response.json())
        .then( (responseJson) => {
          this.setState({
            isLoading: false,
            dataSource: responseJson,
          })    
        })
        .catch((error) => {
          console.log(error);
        });
      }
}

const CalendarPicker = styled(View)`
  color: ${p => p.focused ? '#64b976' : 'grey'};
  opacity: ${p => p.focused ? 1.0 : 0.8};
  padding-top: 20px;
  padding-bottom: 20px;
  background-color: 'rgba(208, 237, 201,0.2)';  
  flex-direction: row;
`;

export default CallendarScreen;