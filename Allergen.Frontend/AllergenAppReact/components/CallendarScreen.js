import * as React from 'react';
import {View, Text, ActivityIndicator, Switch, ListItem, StyleSheet, TouchableOpacity} from 'react-native';
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
          currentDate: new Date()
        }
      }

      componentDidMount(){        
        this.focusListener = this.props.navigation.addListener('focus', () => { 
                console.log('FOCUS is called - date' + moment(this.state.currentDate).format('YYYY-MM-DD'));
               this.state.isLoading=true;
               this.getUserAllergensPolluteFromApi(this.state.currentDate);
               
        });

        //return this.getUserAllergensPolluteFromApi();
      }

      addCalendarDay(dateP,days) {
          newDate = moment(dateP).add(days, 'days').format("YYYY-MM-DD");

          this.setState({currentDate : newDate});          
          
          this.getUserAllergensPolluteFromApi(newDate);
        }


      render() {
        console.log('RENDER CALLENDAR SCREEN'); 
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
                 
              <TouchableOpacity  style={styles.arrowLefttOpacity} onPress={() => this.addCalendarDay(this.state.currentDate,-1)} style={styles.arrowLeft}>
                    <Text style={styles.arrowLeft}> {"<"} </Text>
              </TouchableOpacity>
              
              <Text style={styles.date}>{ moment(this.state.currentDate).format('YYYY-MM-DD') }</Text>   
                
              <TouchableOpacity  style={styles.arrowRightOpacity} onPress={() => this.addCalendarDay(this.state.currentDate,1)} style={styles.arrowRight}>
                <Text style={styles.arrowRight}> {">"} </Text>
              </TouchableOpacity>
                   
              </CalendarPicker>
              
                {allergens}
          </View>
        )
        }
      }
      
      getUserAllergensPolluteFromApi (date) {        
       
        let url = GetUserCallendrUrl + UserId.toString() + "/" + moment(date).format('YYYY-MM-DD');

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